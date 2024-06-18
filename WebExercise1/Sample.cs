using System;

namespace WebExercise1
{

    public interface ISample
    {
        int Id { get; }
    }

    public interface ISingleton : ISample {}

    public interface IScoped : ISample { }

    public interface ITransient : ISample { }

    public class Sample : ISingleton, IScoped, ITransient
    {
        private static int _count;
        private readonly int _id;

        public Sample()
        {
            this._id = ++_count;
        }

        public int Id => _id;
    }

    public class HomeService
    {
        public ISingleton _ISingleton { get; private set; }
        public IScoped _IScoped { get; private set; }
        public ITransient _ITransient { get; private set; }

        public HomeService(ISingleton singleton, IScoped scoped, ITransient transient)
        {
            _ISingleton = singleton;
            _IScoped = scoped;
            _ITransient = transient;
        }
    }

}
