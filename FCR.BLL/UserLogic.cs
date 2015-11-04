//using System.Collections.Generic;

//namespace FCR.BLL
//{
//    public class UserLogic
//    {
//        public UserLogic()
//        {
//            var entities = new PhitnessEntities();
//        }

//        public List<ApiModel.User> GetAllUsers()
//        {
//            var entities = new PhitnessEntities();

//            return entities.Users.ToList().ConvertAll(ConvertUser);
//        }

//        public ApiModel.User GetUser(int id)
//        {
//            var entities = new PhitnessEntities();

//            return ConvertUser(entities.Users.First(x => x.userId == id));
//        }


//        private static ApiModel.User ConvertUser(DAL.User data)
//        {
//            return new ApiModel.User()
//            {
//                Id = data.userId,
//                Name = data.userName
//            };
//        }

//    }
//}