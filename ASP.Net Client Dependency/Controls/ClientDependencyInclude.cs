﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace ClientDependency.Core.Controls
{
    public abstract class ClientDependencyInclude : Control, IClientDependencyFile
	{

		public ClientDependencyInclude()
		{
            Priority = Constants.DefaultPriority;			
			PathNameAlias = "";
		}

		public ClientDependencyInclude(IClientDependencyFile file)
		{
			Priority = file.Priority;
			PathNameAlias = file.PathNameAlias;
			FilePath = file.FilePath;
			DependencyType = file.DependencyType;
		}
        
		public ClientDependencyType DependencyType { get; internal set; }

		public string FilePath { get; set; }
        public string PathNameAlias { get; set; }
        public int Priority { get; set; }

		/// <summary>
		/// This can be empty and will use default provider
		/// </summary>
		public string ForceProvider { get; set; }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			if (string.IsNullOrEmpty(FilePath))
				throw new NullReferenceException("Both File and Type properties must be set");
		}

	}
}
