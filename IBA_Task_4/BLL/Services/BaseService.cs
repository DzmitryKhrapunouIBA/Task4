using System;

namespace BLL.Services
{
    public abstract class BaseService : IDisposable
    {
        public BaseService()
        {
        }

        internal bool disposed = false;

        /// <summary>
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Высвобождение ресурсов.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        ///// <summary>
        ///// </summary>
        ///// <exception cref="OperationCanceledException"></exception>
        ///// <exception cref="ObjectDisposedException"></exception>
        //protected void InitTokenThrow()
        //{
        //    ThrowIfDisposed();
        //}

        /// <summary>
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        protected void ThrowIfDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
