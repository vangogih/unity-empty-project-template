using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using YLAC.Runtime.Utilities.Logging;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace YLAC.Runtime.Utilities
{
    public class SceneManager
    {
        private const string LogTag = "SCENE";
        
        public async UniTask LoadScene(int toLoadIndex)
        {
            int currentSceneIndex = UnitySceneManager.GetActiveScene().buildIndex;
            bool isSkipEmpty = currentSceneIndex == RuntimeConstants.Scenes.Loading || currentSceneIndex == RuntimeConstants.Scenes.Bootstrap || toLoadIndex == currentSceneIndex;

            if (isSkipEmpty)
            {
                Log.Default.D(LogTag, $"Empty scene skipped. {SceneUtility.GetScenePathByBuildIndex(toLoadIndex)} is loading.");
                UnitySceneManager.LoadScene(toLoadIndex);
                return;
            }
            
            bool needLoadEmpty = toLoadIndex == RuntimeConstants.Scenes.Meta || toLoadIndex == RuntimeConstants.Scenes.Core || toLoadIndex == RuntimeConstants.Scenes.Loading;

            if (needLoadEmpty)
            {
                Log.Default.D(LogTag, $"{SceneUtility.GetScenePathByBuildIndex(RuntimeConstants.Scenes.Empty)} is loading.");
                UnitySceneManager.LoadScene(RuntimeConstants.Scenes.Empty);
            }
            
            await UniTask.NextFrame();
            
            Log.Default.D(LogTag, $"{SceneUtility.GetScenePathByBuildIndex(toLoadIndex)} is loading.");
            UnitySceneManager.LoadScene(toLoadIndex);
        }
    }
}