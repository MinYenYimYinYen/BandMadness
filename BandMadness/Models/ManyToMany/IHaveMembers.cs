using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models.ManyToMany
{
	public interface IHaveMembers:IHaveMember
	{
		List<Member> Members { get; set; }
		
	}

	public interface IHaveMember
	{
		MemberSelection MemberSelection { get; set; }
	}
}