using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spitfire_solutions.Dvars
{
    internal class RenderDvars
    {
        public string[,] rVars = new string[34, 2]
        {
            //bloom & blur
            { "r_bloomTweaks", "Enable bloom tweaks. Value: 0 / 1." },
            { "r_bloomHiQuality", "Bloom quality. Value: 0 - 2." },
            { "r_blur", "Enable blur. Value: 0 - 2." },

            //depth of field
            { "r_dof_tweak", "Enable depth of field tweaking. Value: 0 / 1." },
            { "r_dof_enable", "Enable depth of field. Value: 0 / 1." },
            { "r_dof_bias", "Depth of field bias as a power function. Value: 0 - 2." },

            { "r_dof_nearblur", "Sets the radius of near blur." },
            { "r_dof_nearstart", "Depth of field near start distance." },
            {"r_dof_nearend",  "Depth of field near end distance."},

            { "r_dof_farblur", "Sets the radius of far blur." },
            { "r_dof_farstart", "Depth of field far start distance." },
            { "r_dof_farend", "Depth of field far end distance." },

            { "r_dof_viewmodelstart", "Depth of field of viewmodel's start distance. Value: 0 - 5." },
            { "r_dof_viewmodelend", "Depth of field of viewmodel's end distance. Value: 0 - 5." },

            //exposure lighting
            { "r_exposureTweak", "Enable exposure dvar tweaking. Value: 0 / 1." },
            { "r_exposureValue", "Exposure EV stops at. Value: 0 - 10." },
            
            //shadowmapping
            { "r_enablePlayerShadow", "Enable 1st person player shadows. Value: 0 / 1."},
            { "sm_enable", "Enable shadowmapping. Value: 0 / 1." },
            { "sm_sunEnable", "Enable sun shadowmapping from script. Value: 0 / 1." },
            { "sm_fastSunShadow", "Enable fast sun shadows. Value: 0 / 1." },
            { "sm_maxLights", "Limits how many primary lights can have shadow maps. Value: 0 - 4." },
            { "sm_spotEnable", "Enable spot shadow mapping from script. Value: 0 / 1." },
            { "sm_spotQuality", "Spot shadow quality. Value: 0 - 4." },
            { "sm_strictCull", "Strict shadow map culling. Value: 0 / 1." },
            { "sm_sunQuality", "Sun shadow quality. Value: 0 / 4." },
            { "sm_sunShadowScale", "Sun shadow scale optimaziation. Value: 0 - 2." },
            { "sm_sunShadowSmall", "Force quarter sun shadow resolution map. Value: 0 / 1." },


            //sunlight tweaks
            { "r_lighttweakSunLight", "Sunlight strenght. Value: 0 - 30." },
            { "r_lighttweakSunColor", "Sun color. Value: 0-1, 0-1, 0-1. Ex. 0.3 0.9 1" },
            { "r_lighttweakSunDirection", "Sun direction in degrees. Value: -360 - 360, -360-360, 0. Ex. -90 120 0." }


            //level of detail "LODS"
            { "r_lodBiasRigid", "Bias the level of detail distance for rigid models (negative increases detail). Value: -1000 - 1000." },
            { "r_lodBiasSkinned", "Bias the level of detail distance for rigid models (negative increases detail). Value: -1000 - 1000."  },
            { "r_lodScaleRigid", "Scale the level of detail distance for rigid models (larger reduces detail). Value: -1 - 2." },
            { "r_lodBiasRigid", "Bias the level of detail distance for skinned models (negative increases detail). Value: -1 - 2." }

            
            


        };
    }
}
