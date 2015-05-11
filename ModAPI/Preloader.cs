/*  
 *  ModAPI
 *  Copyright (C) 2015 FluffyFish / Philipp Mohrenstecher
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  To contact me you can e-mail me at info@fluffyfish.de
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.IO;
using UnityEngine;
using ModAPI.Configurations;

namespace ModAPI
{
    public class Preloader
    {
        public static Thread LoaderThread;
        
        public static void Load()
        {
            AssemblyResolver.Initialize();
            LoaderThread = new Thread(new ThreadStart(Loader));
            LoaderThread.Start();
        }

        public static void Loader()
        {
            ProgressChain chain = new ProgressChain();
            chain.OnChange += delegate()
            {
                SplashScreen.Progress = chain.Progress * 0.7f;
            };

            chain.AddTask(delegate(ProgressHandler handler) 
            {
                if (Configuration.Load(handler) == Configuration.ResultCode.ERROR)
                {

                }
            }, 30f);

            chain.AddTask(delegate(ProgressHandler handler)
            {
                if (DynamicTypes.Load(handler) == DynamicTypes.ResultCode.ERROR)
                {

                }
            }, 10f);
            
            chain.AddTask(delegate(ProgressHandler handler)
            {
                if (GUIConfiguration.Load(handler) == GUIConfiguration.ResultCode.ERROR)
                {
                    handler.Progress = 100f;
                }
            }, 30f);

            chain.Start();
                /*if (DynamicTypes.Load() == DynamicTypes.ResultCode.OK)
                {
                    SplashScreen.Progress = 100;
                }*/
        }
    }
}
