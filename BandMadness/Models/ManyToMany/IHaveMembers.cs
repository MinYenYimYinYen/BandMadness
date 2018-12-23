using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models.ManyToMany
{
	public interface IHaveMembers
	{
		List<Member> Members { get; set; }
		MemberSelection MemberSelection { get; set; }
	}
}