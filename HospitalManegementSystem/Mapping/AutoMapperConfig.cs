using AutoMapper;
using HospitalManegementSystem.Data.Models;

namespace HospitalManegementSystem.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<DoctorPateint, DoctorPateintDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
            CreateMap<Pateint, PateintDTO>().ReverseMap();
            CreateMap<PateintMedicine, PateintMedicineDTO>().ReverseMap();
            CreateMap<Prescription, PrescriptionDTO>().ReverseMap();
            CreateMap<Ward, WardDTO>().ReverseMap();
            CreateMap<PrescriptionMedicine, PrescriptionMedicineDTO>().ReverseMap();
        }
    }
}
