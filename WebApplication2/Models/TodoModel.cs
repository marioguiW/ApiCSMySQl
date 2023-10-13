namespace MeuTodo.Models;

public class TodoModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Boolean Done { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
