List<string> taskList = new List<string>();

int menuSelected;
do
{
    menuSelected = MainMenu();
    if ((MenuOptions)menuSelected == MenuOptions.AddTask)
    {
        AddTask();
    }
    else if ((MenuOptions)menuSelected == MenuOptions.RemoveTask)
    {
        RemoveTask();
    }
    else if ((MenuOptions)menuSelected == MenuOptions.ShowTaskList)
    {
        ShowMenuTaskList();
    }
} while ((MenuOptions)menuSelected != MenuOptions.Exit);

/// <summary>
/// Muestra el menú principal de la aplicación
/// 1. Nueva tarea
/// 2. Remover tarea
/// 3. Tareas pendientes
/// 4. Salir
/// </summary>
/// <returns>Retorna la opción seleccionada</returns>
int MainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Bienvenido a ToDo");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");
    Console.WriteLine("----------------------------------------");
    string option = Console.ReadLine();
    return Convert.ToInt32(option);
}

/// <summary>
/// Remueve una tarea de la lista de tareas
/// </summary>
void RemoveTask()
{
    try
    {
        if (taskList == null || taskList.Count == 0)
        {
            Console.WriteLine("No hay tareas por realizar");
        }
        else
        {
            ShowTaskList();
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            string option = Console.ReadLine();
            // Se resta 1 porque el índice de la lista inicia en 0
            int taskIndexToRemove = Convert.ToInt32(option) - 1;
            if (taskIndexToRemove > (taskList.Count - 1) || taskIndexToRemove < 0)
            {
                Console.WriteLine("El número de tarea ingresado no existe");
            }
            else
            {
                RemoveTaskList(taskIndexToRemove);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void RemoveTaskList(int taskIndexToRemove)
{
    string task = taskList[taskIndexToRemove];
    taskList.RemoveAt(taskIndexToRemove);
    Console.WriteLine($"Tarea {task} removida");
}

void AddTask()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskNumber = Console.ReadLine();
        taskList.Add(taskNumber);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al registrar la tarea: \n{ex.Message}");
    }
}

void ShowMenuTaskList()
{
    if (taskList?.Count == 0)
    {
        Console.WriteLine("No hay tareas por realizar");
    }
    else
    {
        ShowTaskList();
    }
}

void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;
    taskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));
    Console.WriteLine("----------------------------------------");
}

public enum MenuOptions
{
    AddTask = 1,
    RemoveTask = 2,
    ShowTaskList = 3,
    Exit = 4
}