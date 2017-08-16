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

namespace ModAPI.Utils
{
    public class Schedule
    {
        protected static Dictionary<string, List<Task>> Tasks = new Dictionary<string, List<Task>>();
        protected static int LastTaskId;

        public static Task AddTask(string target, string taskName, Action complete, object[] parameters, Func<bool> check = null)
        {
            target = target.ToLower();
            LastTaskId += 1;
            var newTask = new Task(LastTaskId, target, taskName, parameters, complete, check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string target, string taskName, Action complete, Func<bool> check = null)
        {
            target = target.ToLower();
            LastTaskId += 1;
            var newTask = new Task(LastTaskId, target, taskName, new object[0], complete, check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string taskName, Action complete, object[] parameters, Func<bool> check = null)
        {
            LastTaskId += 1;
            var newTask = new Task(LastTaskId, "global", taskName, parameters, complete, check);
            AddTask(newTask);
            return newTask;
        }

        public static Task AddTask(string taskName, Action complete, Func<bool> check = null)
        {
            LastTaskId += 1;
            var newTask = new Task(LastTaskId, "global", taskName, new object[0], complete, check);
            AddTask(newTask);
            return newTask;
        }

        public static List<Task> GetTasks(string target, bool includeGlobal = true)
        {
            target = target.ToLower();
            var ret = new List<Task>();
            if (Tasks.ContainsKey("global"))
            {
                ret.AddRange(Tasks["global"]);
            }
            if (Tasks.ContainsKey(target))
            {
                ret.AddRange(Tasks[target]);
            }
            return ret;
        }

        protected static void AddTask(Task task)
        {
            if (!Tasks.ContainsKey(task.Target))
            {
                Tasks.Add(task.Target, new List<Task>());
            }
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
            public int Id;
            public string Name;
            public object[] Parameters;
            public bool BeingHandled = false;

            public Task(int id, string target, string name, object[] parameters, Action complete, Func<bool> check = null)
            {
                Parameters = parameters;
                Target = target;
                Id = id;
                Name = name;
                _Check = check;
                _Complete = complete;
            }

            public bool Check()
            {
                if (_Check != null)
                {
                    return _Check();
                }
                return true;
            }

            public void Complete()
            {
                Schedule.Complete(this);
                _Complete?.Invoke();
            }
        }
    }
}
