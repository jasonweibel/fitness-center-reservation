using System;

namespace FCR.Core.Ioc
{
    /// <summary>
    /// A TypeFinder is used to find types to be added to the container.
    /// https://mvcarchstarter.svn.codeplex.com/svn/Core/Ioc/ITypeFinder.cs
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// Get the types to add the container.
        /// </summary>
        /// <returns>The types found.</returns>
        Type[] GetTypes();
    }
}