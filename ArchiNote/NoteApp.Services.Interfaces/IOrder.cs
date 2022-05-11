using NoteApp.Domain.Core;

namespace IOrder
{
    public interface IOrder
    {
        void MakeOrder(Note note);
    }
}