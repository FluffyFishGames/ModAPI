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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModAPI
{
    public class ProgressChain
    {
        public delegate void TaskMethod(ProgressHandler handler);
        public delegate void Complete();
        public delegate void Change();

        public float Progress = 0f;
        public Complete OnComplete;
        public Change OnChange;
        protected List<Task> Tasks = new List<Task>();
        protected int currentTask = 0;
        protected float overallWeight = 0f;

        public void AddTask(TaskMethod task, float weight)
        {
            Tasks.Add(new Task(this, weight, task));
            overallWeight += weight;
        }

        protected void ProgressChanged()
        {
            float progress = 0f;
            foreach (Task t in Tasks)
            {
                progress += (t.Progress.Progress) * (t.Weight / overallWeight);
            }
            Progress = progress;
            if (OnChange != null)
                OnChange();
            if (Progress == 100f && OnComplete != null)
                OnComplete();
        }

        public void Start()
        {
            Progress = 0;
            currentTask = -1;
            Next();
        }

        protected void Next()
        {
            currentTask += 1;
            if (Tasks.Count <= currentTask)
            {
                if (OnComplete != null)
                    OnComplete();
            }
            else
                Tasks[currentTask].Start();
        }

        public class Task
        {
            public ProgressHandler Progress;
            public ProgressChain.TaskMethod Method;
            public float Weight = 0f;
            protected ProgressChain chain;

            public void Start()
            {
                this.Method(this.Progress);
            }

            public Task(ProgressChain chain, float weight, ProgressChain.TaskMethod method)
            {
                this.Weight = weight;
                this.chain = chain;
                Progress = new ProgressHandler();
                Progress.OnChange += (s, e) => 
                {
                    chain.ProgressChanged();
                };
                Progress.OnComplete += (s, e) =>
                {
                    chain.Next();
                };
                Method = method;
            }
        }
    }
}
