using System;
using UnityEngine;
using UnityEngine.UI;

namespace YLAC.ConnectionTypes.SubscriptionBased
{
    public class Feaure
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
                private SubSubFeature1 _subsub;
                public event Action OnClicked
                {
                    add => _subsub.OnClicked += value;
                    remove => _subsub.OnClicked -= value;
                }

                public SubFeature1()
                {
                    _subsub = new SubSubFeature1();
                }

                private class SubSubFeature1
                {
                    public event Action OnClicked
                    {
                        add => _subsubsub.OnBtnClicked += value;
                        remove => _subsubsub.OnBtnClicked -= value;
                    }
                    private SubSubSubFeature1 _subsubsub;

                    public SubSubFeature1()
                    {
                        _subsubsub = new GameObject().AddComponent<SubSubSubFeature1>();
                        _subsubsub.Initialize();
                    }

                    private class SubSubSubFeature1 : MonoBehaviour
                    {
                        [SerializeField] private Button _btn;
                        public Action OnBtnClicked;

                        public void Initialize()
                        {
                            _btn.onClick.AddListener(() => OnBtnClicked.Invoke());
                        }
                    }
                }
            }

            public Two(One one)
            {
                _one = one;

                var subFeature1 = new SubFeature1();
                subFeature1.OnClicked += BtnClicked;
            }

            private void BtnClicked()
            {
                _one.Do();
            }

            public void Do() { }
        }
    }
}