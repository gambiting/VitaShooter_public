using System.Collections.Generic;
using System.Xml;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Imaging;	// Font
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace VitaShooter
{
	public class Layer
    : Node
    {
    }
	
	public class AppMain
	{
		
		
		static FontMap UIFontMap;
		static FontMap LargeFontMap;
		
		public static void Main(string[] args)
		{
			Director.Initialize();

			Director.Instance.GL.Context.SetClearColor( Colors.Grey20 );
			Director.Instance.DebugFlags |= DebugFlags.DrawGrid;
			
			

			//UICamera = new Camera2D( Director.Instance.GL, Director.Instance.DrawHelpers );
			//UICamera.SetViewFromWidthAndCenter( 16.0f, Math._00 );

			UIFontMap = new FontMap( new Font( FontAlias.System, 20, FontStyle.Bold ) );
			LargeFontMap = new FontMap( new Font( FontAlias.System, 48, FontStyle.Bold ) );
			
			//make a new Game object
			Game.Instance = new Game();
			var game = Game.Instance;
			
			
			Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.RunWithScene(game.Scene,true);
			
			System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

            while (true)
            {
            	timer.Start();
                SystemEvents.CheckEvents();


                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.SetBlendMode(BlendMode.Normal);
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Update();
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.Render();
				
                game.FrameUpdate();
                
            	timer.Stop();
                long ms = timer.ElapsedMilliseconds;
                //Console.WriteLine("ms: {0}", (int)ms);
            	timer.Reset();

                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.GL.Context.SwapBuffers();
                Sce.PlayStation.HighLevel.GameEngine2D.Director.Instance.PostSwap();
            }
			
		}

	}
}
