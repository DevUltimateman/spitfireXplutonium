using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.Dvars
{
    internal class ClientGameDvars
    {
        public List<ClientGameDvars> cDvarsList;
        public bool IsServerGame { get; set; }
        public string CvarInfo { get; set; }
        public string CvarInfoValue { get; set; }
        public string CvarInfoDescription { get;set; }
        List<string> list = new List<string>();
        // public List TestList = 

        //All cg_<> dvars
        //in a multi dimensional array
        public string[ , ] cDvars = new string[ 18, 2 ]
        {
            {"cg_fov", "User's field of view. Value: 40 - 200" },   
            { "cg_fov_default", "User's default / permament field of view. Value: 40 - 200" },
            { "cg_fovscale", " Scale that cg_fov gets multiplied by. Value: 1.0 - 2.0" },
            { "cg_colorHue",  "RGB color alternation. Value: 0 - 360"  },
            { "cg_colorSaturation", "De- / Saturate rendered image. Value: 0 - 2"  },
            { "cg_drawCrosshair",  "Draw player's crosshair. Value: 0 - 1"  },
            { "cg_crosshairAlpha",  "Crosshair see thru amount. Value: 0 - 1"  },
            { "cg_cursorHints", "Alternates how hintstrings are rendered on screen. Value: 0 - 4"  },
            { "cg_draw2d", "Draw 2d hud on screen. Value: 0 / 1"  },
            { "cg_drawLagometer",  "Draw lag meter: Value: 0 / 1" },
            { "cg_drawFps",  "Draw fps on player's screen. Value: 0 - 3"  },
            { "cg_thirdperson",  "Enable third person mode. Value: 0 / 1"  },
            { "cg_thirdpersonmode",  "Third person mode style. Value: 0 - 3"  },
            { "cg_thirdpersonangle", "Third person camera angles. Value: 0 - 360"  },
            { "cg_gun_x",  "Gun position on the horizontal axis. Value: -2 - 2"  },
            { "cg_gun_y",  "Gun position on the vertical axis. Value: -2 - 2"  },
            { "cg_gun_z",  "Gun position on the depth axis. Value: -2 - 2"  },
            { "cg_ufo_scaler",  "Scale that gets applied to ufo move speed. Value: 0 - 2"  }
        };

        public void MakeList()
        {
            cDvarsList.Clear();
            int counter = cDvars.Length;

            for( int i = 0; i < counter; i++ )
            {
                //dohere
            }
        }
        public void FillCvarList()
        {
            int passby = 0;
            
            while( passby < cDvars.Length  )
            {
                list.Add(cDvars[passby, 0]);
                list.Add(cDvars[passby, 1]);
                passby++;
            }
            passby = 0;
            Console.WriteLine(cDvarsList.ToString());
            

        }
    }
}
