using UnityEngine;
using UnityEngine.UI;

namespace YLAC.ConnectionTypes.AddressBased
{
    public class Feature
    {
        public class One
        {
            private SubFeature1 _subFeature1;
            private SubFeature2 _subFeature2;
            private SubFeature3 _subFeature3;

            private class SubFeature1
            {
                public void Do() { }
            }

            private class SubFeature2
            {
                private readonly SubFeature1 _subFeature1;

                public SubFeature2(SubFeature1 subFeature1)
                {
                    _subFeature1 = subFeature1;
                }

                public void Do()
                {
                    _subFeature1.Do();
                }
            }

            private class SubFeature3
            {
                private readonly SubFeature1 _sub1;
                private readonly SubFeature2 _sub2;

                public SubFeature3(SubFeature1 sub1, SubFeature2 sub2)
                {
                    _sub1 = sub1;
                    _sub2 = sub2;
                }

                public void Do()
                {
                    _sub2.Do();
                    _sub1.Do();
                }
            }

            public One()
            {
                _subFeature1 = new SubFeature1();
                _subFeature2 = new SubFeature2(_subFeature1);
                _subFeature3 = new SubFeature3(_subFeature1, _subFeature2);
            }

            public void Do()
            {
                _subFeature3.Do();
            }
        }

        public class Two
        {
            private readonly One _one;

            private class SubFeature1
            {
                public SubFeature1(Two two)
                {
                    var subsub = new SubSubFeature1(two);
                }
                private class SubSubFeature1
                {
                    public SubSubFeature1(Two two)
                    {
                        var subsubsub = new GameObject().AddComponent<SubSubSubFeature1>();
                        subsubsub.Initialize(two);
                    }

                    private class SubSubSubFeature1 : MonoBehaviour
                    {
                        [SerializeField] private Button _btn;
                        private Two _two;

                        public void Initialize(Two two)
                        {
                            _two = two;
                            _btn.onClick.AddListener(OnBtnClick);
                        }

                        private void OnBtnClick()
                        {
                            _two.BtnClicked();
                        }
                    }
                }
                
            }

            public Two(One one)
            {
                _one = one;

                var subFeature1 = new SubFeature1(this);
            }

            public void BtnClicked()
            {
                _one.Do();
            }

            public void Do()
            {
            }
        }
    }
}