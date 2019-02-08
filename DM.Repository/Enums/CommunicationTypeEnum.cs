using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Repository.Enums
{
    public class CommunicationTypeEnum
    {
        public static Guid SmsIWToScheduleAppointment = new Guid("B0560D26-6BBE-4709-A80F-1BAF9E8B4179");
        public static Guid SmsProviderBidRequest = new Guid("65B2192D-BB1B-403D-8160-31D1D8E50782");
        public static Guid EmailToOperationsOnIWNotSchedule = new Guid("977A732A-774C-4623-B11D-326930390CDB");
        public static Guid EmailIWScheduleReceivedThankYou = new Guid("357F3FA1-969F-4C47-82DD-3B012D6FE8E1");
        public static Guid RemainderSmsIWToScheduleAppointment = new Guid("9CAA9BC7-84D0-4CAD-BA9F-5FF53B193D3E");
        public static Guid RemainderEmailIWToScheduleAppointment = new Guid("EF4FB3EA-764F-4FBE-8440-3F8B185AC73D");
        public static Guid EmailProviderBidRequest = new Guid("5CE1549A-DF3B-4F74-9BBB-AF180BC02D9F");
        public static Guid EmailIWToScheduleAppointment = new Guid("44702FDE-F501-4D53-93CC-FFDF0D50A647");
        public static Guid EmailProcessedProviders = new Guid("B1A8BA85-1031-46DC-A7AB-0E52B546E965");
        public static Guid EmailActorUpdateInfo = new Guid("965F28B0-D4D1-4A9C-80FC-05B820F1FBE3");

    }
}
