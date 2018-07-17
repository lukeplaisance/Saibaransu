using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public interface IState
    {
        void OnEnter(IContext context);
        void UpdateState(IContext context);
        void OnExit(IContext context);
    }

    public interface IContext
    {
        IState CurrentState { get; set; }
        void UpdateContext();
        void ChangeState(IState state);
    }

    public class GameContext : IContext
    {
        public IState CurrentState { get; set; }

        public void ChangeState(IState state)
        {
            CurrentState.OnExit(this);
            CurrentState = state;
            state.UpdateState(this);
            state.OnEnter(this);
        }

        public void UpdateContext()
        {

        }
    }

    class MainMenu : IState
    {
        public void OnEnter(IContext context)
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnExit(IContext context)
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }
        public void UpdateState(IContext context)
        {
            context.ChangeState(this);
        }
    }
    class Gameplay : IState
    {
        public void OnEnter(IContext context)
        {
            SceneManager.LoadScene("Luke");
        }

        public void OnExit(IContext context)
        {
            SceneManager.UnloadSceneAsync("Luke");
        }

        public void UpdateState(IContext context)
        {
            context.ChangeState(this);
        }
    }
    class GameOver : IState
    {
        public void OnEnter(IContext context)
        {

        }

        public void OnExit(IContext context)
        {
        }

        public void UpdateState(IContext context)
        {
        }
    }

    class Pause : IState
    {
        public void OnEnter(IContext context)
        {

        }

        public void OnExit(IContext context)
        {
        }

        public void UpdateState(IContext context)
        {
        }
    }

    class Exit : IState
    {
        public void OnEnter(IContext context)
        {
            SceneManager.UnloadSceneAsync("Luke");
            SceneManager.UnloadSceneAsync("MainMenu");
        }

        public void OnExit(IContext context)
        {
        }

        public void UpdateState(IContext context)
        {
        }
    }
}
