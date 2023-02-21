﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if(indexToRemove > (TaskList.Count -1) || indexToRemove <-0){
                    Console.WriteLine($"La tarea {line} no existe");
                }else {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {                    
                        string numeroTareaSeleccionada = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + numeroTareaSeleccionada + " eliminada");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocudrrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string agregarTarea = Console.ReadLine();
                TaskList.Add(agregarTarea);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al registrar la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowTaskList();
            }
        }
        public static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask=1;
            TaskList.ForEach(p=> Console.WriteLine(indexTask++ + ". " + p));
                Console.WriteLine("----------------------------------------");
        }
    }
    public enum Menu{
        add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
