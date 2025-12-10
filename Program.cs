using System.Text;
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Media Player State Pattern ---");

        Player player = new Player();

        player.PressPause(); 

        player.PressPlay();

        player.PressPause();

        player.PressPlay();

        player.PressStop();
    }
    public class Player
    {
        private IPlayerState _state;
        public Player()
        {
            _state = new StoppedState();
        }
        public void SetState(IPlayerState state)
        {
            _state = state;
        }
        public void PressPlay()
        {
            _state.Play(this);
        }

        public void PressPause()
        {
            _state.Pause(this);
        }

        public void PressStop()
        {
            _state.Stop(this);
        }
    }
    public interface IPlayerState
    {
        void Play(Player player);
        void Pause(Player player);
        void Stop(Player player);
    }
    public class StoppedState : IPlayerState
    {
        public void Play(Player player)
        {
            Console.WriteLine("Starting Player...");
            player.SetState(new PlayingState());
        }

        public void Pause(Player player)
        {
            Console.WriteLine("Error: Cannot pause. Player is currently stopped.");
        }

        public void Stop(Player player)
        {
            Console.WriteLine("Error: Already stopped.");
        }
    }
    public class PlayingState : IPlayerState
    {
        public void Play(Player player)
        {
            Console.WriteLine("Error: Already playing.");
        }

        public void Pause(Player player)
        {
            Console.WriteLine("Pausing ...");
            player.SetState(new PausedState());
        }

        public void Stop(Player player)
        {
            Console.WriteLine("Stopping ...");
            player.SetState(new StoppedState());
        }
    }
    public class PausedState : IPlayerState
    {
        public void Play(Player player)
        {
            Console.WriteLine("Resuming ...");
            player.SetState(new PlayingState());
        }

        public void Pause(Player player)
        {
            Console.WriteLine("Error: Already paused.");
        }

        public void Stop(Player player)
        {
            Console.WriteLine("Stopping from pause...");
            player.SetState(new StoppedState());
        }
    }
}


