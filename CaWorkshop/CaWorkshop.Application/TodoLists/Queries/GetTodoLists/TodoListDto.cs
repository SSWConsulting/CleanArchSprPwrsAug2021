using System.Collections.Generic;
using CaWorkshop.Application.Common.Mapping;
using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<TodoItemDto> Items { get; set; }
    }
}
