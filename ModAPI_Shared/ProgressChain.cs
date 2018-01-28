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

using System.Collections.Generic;

namespace ModAPI
{
    public class ProgressChain
    {
        public delegate void TaskMethod(ProgressHandler handler);

        public delegate void Complete();

        public delegate void Change();

        public float Progress;
        public Complete OnComplete;
        public Change OnChange;
        protected List<Task> Tasks = new List<Task>();
        protected int CurrentTask;
        protected float OverallWeight;

        public void AddTask(TaskMethod task, float weight)
        {
            Tasks.Add(new Task(this, weight, task));
            OverallWeight += weight;
        }

        protected void ProgressChanged()
        {
            var progress = 0f;
            foreach (var t in Tasks)
            {
                progress += (t.Progress.Progress) * (t.Weight / OverallWeight);
            }
            Progress = progress;
            OnChange?.Invoke();
            if (Progress == 100f && OnComplete != null)
            {
                OnComplete();
            }
        }

        public void Start()
        {
            Progress = 0;
            CurrentTask = -1;
            Next();
        }

        protected void Next()
        {
            CurrentTask += 1;
            if (Tasks.Count <= CurrentTask)
            {
                OnComplete?.Invoke();
            }
            else
            {
                Tasks[CurrentTask].Start();
            }
        }

        public class Task
        {
            public ProgressHandler Progress;
            public TaskMethod Method;
            public float Weight;
            protected ProgressChain Chain;

            public void Start()
            {
                Method(Progress);
            }

            public Task(ProgressChain chain, float weight, TaskMethod method)
            {
                Weight = weight;
                Chain = chain;
                Progress = new ProgressHandler();
                Progress.OnChange += (s, e) => { chain.ProgressChanged(); };
                Progress.OnComplete += (s, e) => { chain.Next(); };
                Method = method;
            }
        }
    }
}
