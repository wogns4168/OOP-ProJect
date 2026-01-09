using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWeapon.Scenes;
using MoneyWeapon.Utils;

namespace MoneyWeapon.Managers
{
    internal static class SceneManager
    {
        public static Action OnChangeScene;

        public static Scene Current {  get; private set; }
        private static Scene _prev;

        private static Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

        public static void AddScene(string key, Scene scene)
        {
            if(_scenes.ContainsKey(key)) return;

            _scenes.Add(key, scene);
        }

        public static void ChangePrevScene()
        {
            Change(_prev);
        }

        public static void Change(string key)
        {
            if (!_scenes.ContainsKey(key)) return;

            Change(_scenes[key]);
        }

        public static void Change(Scene scene)
        {
            Scene next = scene;

            if (Current == next) return;

            Current?.Exit();
            _prev = Current;
            Current = next;
            Current.Enter();

            OnChangeScene?.Invoke();
        }

        public static void Update()
        {
            Current?.Update();
        }

        public static void Render()
        {
            Current?.Render();
        }

    }
}
