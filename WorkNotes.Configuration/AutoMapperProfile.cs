using AutoMapper;
using MongoDB.Bson;
using System;
using WorkNotes.Entities;
using WorkNotes.Models.ViewModel;

namespace WorkNotes.Configuration
{
    public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Project, ProjectViewModel>().ReverseMap();
			CreateMap<CheckIn, CheckInViewModel>().ReverseMap();
			CreateMap<Note, NoteViewModel>().ReverseMap();
			CreateMap<ObjectId, string>().ConvertUsing(x => x.ToString());
			CreateMap<string, ObjectId>().ConvertUsing(x => ObjectId.Parse(x.ToString()));
		}
	}
}
