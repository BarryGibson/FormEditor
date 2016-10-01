﻿using System;
using System.Collections.Generic;

namespace FormEditor.Storage
{
	/// <summary>
	/// This interface describes a Form Editor storage index that supports updating entries
	/// </summary>
	/// <remarks>
	/// In an upcoming release, this interface will be merged into IIndex
	/// </remarks>
	public interface IUpdateIndex
	{
		/// <summary>
		/// Updates an entry in the index
		/// </summary>
		/// <param name="fields">The field names and values to update</param>
		/// <param name="rowId">The ID of the entry to update</param>
		/// <returns>The ID of the form entry</returns>
		Guid Update(Dictionary<string, string> fields, Guid rowId);
	}
}