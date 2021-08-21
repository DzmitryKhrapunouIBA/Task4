using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL.Contracts
{
    public interface ICrudService<T>
    {
        /// <summary>
        /// Получение всех сущностей.
        /// </summary>
        /// <returns>Коллекция найденных элементов.</returns>
        IEnumerable<T> All();

        /// <summary>
        /// Поиск и получение сущностей.
        /// </summary>
        /// <param name="func">Функция поиска.</param>
        /// <returns>Коллекция найденных элементов.</returns>
        IEnumerable<T> All(Func<T, bool> func, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Получение единственной сущности по коду
        /// </summary>
        /// <param name="id">Код сущности.</param>
        /// <returns>Найденный элемент.</returns>
        T Get(int id);

        /// <summary>
        /// Получение единственного элемента по выражению
        /// </summary>
        /// <param name="func">Функция поиска элемента.</param>
        /// <returns>
        /// Возвращает найденный элемент.
        /// </returns>
        T Get(Expression<Func<T, bool>> func);

        /// <summary>
        /// Создание сущности.
        /// </summary>
        /// <param name="item">Объект создаваемой сущности.</param>
        /// <returns>
        /// Возвращает объект созданной сущности.
        /// </returns>
        T Create(T item);

        /// <summary>
        /// Изменение сущности.
        /// </summary>
        /// <param name="item">Объект изменяемой сущности.</param>
        /// <returns>
        /// Возвращает успех операции.
        /// </returns>
        bool Update(T item);

        /// <summary>
        /// Удаление сущности.
        /// </summary>
        /// <param name="item">Объект изменяемой сущности.</param>
        /// <returns>
        /// Возвращает успех операции.
        /// </returns>
        bool Delete(int id);
    }
}
