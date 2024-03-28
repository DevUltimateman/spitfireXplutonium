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
        
        //All cg_<> dvars
        //in a multi dimensional array
        public string[ ,, ] cDvars =
        {
            {{"cg_fov", "40 - 200", "User's field of view" }},
            {{ "cg_fov_default", "40 - 200", "User's default / permament field of view" }},
            {{ "cg_fovscale", "1.0 - 2.0", "Scale that cg_fov gets multiplied by" }},
            {{ "cg_colorHue", "0 - 360", "RGB color alternation" } },
            {{ "cg_colorSaturation", "0 - 2", "De- / Saturate rendered image" } },
            {{"cg_drawCrosshair", "0 / 1", "Draw player's crosshair" } },
            {{ "cg_crosshairAlpha", "0 / 1", "Crosshair see thru amount" } },
            { {"cg_cursorHints", "0 - 4", "Alternates how hintstrings are rendered on screen" } },
            {{ "cg_draw2d", "0 - 1", "Draw 2d hud on screen" } },
            {{ "cg_drawLagometer", "0 - 1", "Draw lag meter" } },
            {{ "cg_drawFps", "0 - 3", "Draw fps on player's screen" } },
            {{ "cg_thirdperson", "0 - 1", "Enable third person mode" } },
            {{ "cg_thirdpersonmode", "0 - 3", "Third person mode style" } },
            {{ "cg_thirdpersonangle", "0 - 360", "Third person camera angles" } },
            {{ "cg_gun_x", "-2 - 2", "Gun position on the horizontal axis" } },
            {{ "cg_gun_y", "-2 - 2", "Gun position on the vertical axis" } },
            {{ "cg_gun_z", "-2 - 2", "Gun position on the depth axis" } },
            {{ "cg_ufo_scaler", "-2 - 2", "Scale that gets applied to ufo move speed" } }
        };

        public string[] cDvarsValues =
        {
            "40-120",
            "40-120",
            "1 - 2",
            "0 - 360",
            ""
        };

        public void FillCvarList()
        {
            ClientGameDvars cl = new ClientGameDvars();
            int passby = 0;
            while( passby < cDvars.Length  )
            {
                cDvarsList.Add(new ClientGameDvars()
                {
                    //[ 0 ] = dvar in question
                    //[ 1 ] = dvar's return value
                    //[ 2 ] = dvar's infotext for user
                    CvarInfo = cDvars[passby, 0, 0],
                    CvarInfoValue = cDvars[passby, 0, 1],
                    CvarInfoDescription = cDvars[passby, 0, 2]

                }) ;
                passby++;
            }
            

        }
    }
}
