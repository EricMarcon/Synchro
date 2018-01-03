/*****************************************************************************
  Copyright © 2003 - 2005 by Martin Cook. All rights are reserved. If you like
  this code then feel free to go ahead and use it. The only thing I ask is 
  that you don't remove or alter my copyright notice. Your use of this 
  software is entirely at your own risk. I make no claims about the 
  reliability or fitness of this code for any particular purpose. If you 
  make changes or additions to this code then please clearly mark your code 
  as yours. If you have questions or comments then please contact me at: 
  martin@codegator.com
  
  Have Fun! :o)
*****************************************************************************/

#region Using directives

using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using CG.Core.Resource;

#endregion

namespace CG.Animation.Design
{
	/// <summary>
	/// A file-name editor specialized for AVI files.
	/// </summary>
	public sealed class CGAVIFileEditor : System.Windows.Forms.Design.FileNameEditor
	{
	
		// ******************************************************************
		// Constructos.
		// ******************************************************************

		#region Constructors

		/// <summary>
		/// Creates a new instance of the CGAVIFileEditor class.
		/// </summary>
		public CGAVIFileEditor()
		{
		
		} // End CGAVIFileEditor()
 
		#endregion

		// ******************************************************************
		// Overrides.
		// ******************************************************************
        
		#region Overrides

		/// <summary>
		/// Initializes the file-open dialog.
		/// </summary>
		/// <param name="openFileDialog">The dialog to be initialized.</param>
		protected override void InitializeDialog(
			OpenFileDialog openFileDialog
			)
		{

			
			openFileDialog.Title = CGResource.GetString(
				typeof(CGAVIFileEditor),
				"dialog_title"
				);

			openFileDialog.Filter = CGResource.GetString(
				typeof(CGAVIFileEditor),
				"dialog_filter"
				);

			openFileDialog.DefaultExt = CGResource.GetString(
				typeof(CGAVIFileEditor),
				"default_ext"
				);

			openFileDialog.CheckFileExists = true;
			openFileDialog.DereferenceLinks = true;
			
		} // End InitializeDialog()

		#endregion
         
	} // End class CGAVIFileEditor

} // End namespace CG.Animation.Design
