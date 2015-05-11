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

namespace ModAPI.Utils
{
    public class Schedule
    {
        protected static Dictionary<string, List<Task>> Tasks = new Dictionary<string, List<Task>>();
        protected static int LastTaskID = 0;
        public static Task AddTask(string Target, string TaskName, Action Complete, object[] Parameters, Func<bool> Check = null)
        {
            Target = Target.ToLower();
            LastTaskID += 1;
            Task newTask = new Task(LastTaskID, Target, TaskName, Parameters, Complete, Check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string Target, string TaskName, Action Complete, Func<bool> Check = null)
        {
            Target = Target.ToLower();
            LastTaskID += 1;
            Task newTask = new Task(LastTaskID, Target, TaskName, new object[0], Complete, Check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string TaskName, Action Complete, object[] Parameters, Func<bool> Check = null)
        {
            LastTaskID += 1;
            Task newTask = new Task(LastTaskID, "global", TaskName, Parameters, Complete, Check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string TaskName, Action Complete, Func<bool> Check = null)
        {
            LastTaskID += 1;
            Task newTask = new Task(LastTaskID, "global", TaskName, new object[0], Complete, Check);
            AddTask(newTask);
            return newTask;
        }

        public static List<Task> GetTasks(string Target, bool includeGlobal = true)
        {
            Target = Target.ToLower();
            List<Task> ret = new List<Task>();
            if (Tasks.ContainsKey("global"))
                ret.AddRange(Tasks["global"]);
            if (Tasks.ContainsKey(Target))
                ret.AddRange(Tasks[Target]);
            return ret;
        }

        protected static void AddTask(Task task)
        {
            if (!Tasks.ContainsKey(task.Target))
                Tasks.Add(task.Target, new List<Task>());
            Tasks[task.Target].Add(task);
        }

        protected static void Complete(Task task)
        {
            Tasks[task.Target].Remove(task);
        }

        public class Task 
        {
            protected Func<bool> _Check;
            protected Action _Complete;
            public string Target;
            public int ID;
            public string Name;
            public object[] Parameters;
            public bool BeingHandled = false;

            public Task(int ID, string Target, string Name, object[] Parameters, Action Complete, Func<bool> Check = null)
            {
                this.Parameters = Parameters;
                this.Target = Target;
                this.ID = ID;
                this.Name = Name;
                _Check = Check;
                _Complete = Complete;
            }

            public bool Check() 
            {
                if (_Check != null)
                    return _Check();
                return true;
            }

            public void Complete() 
            {
                Schedule.Complete(this);
                if (_Complete != null)
                    _Complete();
            }
        }
    }
}
