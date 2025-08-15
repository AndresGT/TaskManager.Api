namespace  TaskManager.Api.Models
{
 public class TaskItem
 {
     public int Id {get; set;}
     public String Title {get; set;} = String.Empty;
     public bool IsCompleted {get; set;} = false;
 }
}