using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Asha
{
    public class Loader : MonoBehaviour
    {
        private void Awake()
        {
            Load();
        }

        public static void Load()
        {
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamReader sR = new StreamReader(fS);
                while (sR.Peek() != -1)
                {
                    Options.MS_Background_URL = sR.ReadLine();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static void Save()
        {
            try
            {
                FileStream fS = new FileStream($"{Application.dataPath}/StreamingAssets/Setting.ygo", FileMode.OpenOrCreate);
                StreamWriter sW = new StreamWriter(fS);

                sW.WriteLine(Options.MS_Background_URL);


            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}

