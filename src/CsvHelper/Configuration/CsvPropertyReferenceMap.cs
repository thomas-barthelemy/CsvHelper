// Copyright 2009-2014 Josh Close and Contributors
// This file is a part of CsvHelper and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
// http://csvhelper.com
using System;
using System.Linq;
using System.Reflection;

namespace CsvHelper.Configuration
{
	/// <summary>
	/// Mapping info for a reference property mapping to a class.
	/// </summary>
	public class CsvPropertyReferenceMap
	{
		private readonly PropertyInfo property;

		/// <summary>
		/// Gets the property.
		/// </summary>
		public PropertyInfo Property
		{
			get { return property; }
		}

		/// <summary>
		/// Gets the mapping.
		/// </summary>
		public CsvClassMap Mapping { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CsvPropertyReferenceMap"/> class.
		/// </summary>
		/// <param name="property">The property.</param>
		/// <param name="mapping">The <see cref="CsvClassMap"/> to use for the reference map.</param>
		public CsvPropertyReferenceMap( PropertyInfo property, CsvClassMap mapping )
		{
			if( mapping == null )
			{
				throw new ArgumentNullException( "mapping" );
			}

			this.property = property;
			Mapping = mapping;
		}

		/// <summary>
		/// Get the largest index for the
		/// properties and references.
		/// </summary>
		/// <returns>The max index.</returns>
		internal int GetMaxIndex()
		{
			return Mapping.GetMaxIndex();
		}

	    /// <summary>
	    /// Sets a name in the referenced map for a specified property.
	    /// </summary>
	    /// <param name="propertyName">
	    /// The name of a property in the referenced <see cref="CsvClassMap"/>.
	    /// </param>
        /// <param name="names">The possible names of the CSV field.</param>
	    public CsvPropertyReferenceMap PropertyName( string propertyName, params string[] names )
	    {
            if ( names == null || names.Length == 0 )
            {
                throw new ArgumentNullException( "names" );
            }

	        var propertyMap = Mapping.PropertyMaps.FirstOrDefault( p => Equals( p.Data.Property.Name ) );

            if (propertyMap == null) return this;

            propertyMap.Data.Names.Clear();
            propertyMap.Data.Names.AddRange( names );
            propertyMap.Data.IsNameSet = true;
	        
            return this;
	    }
	}
}
