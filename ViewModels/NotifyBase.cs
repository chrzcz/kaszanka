using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Kaszanka.ViewModels
{
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Notify<TClass, TProp>(TClass _, Expression<Func<TClass, TProp>> expression)
        {
            var name = ((expression.Body as MemberExpression)?.Member as PropertyInfo)?.Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
