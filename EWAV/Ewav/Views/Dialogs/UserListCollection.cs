using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace EWAV
{
    public class UserListCollection : ObservableCollection<UserListInfo>
    {
        public UserListCollection(List<UserListInfo> userList) : base()
        {
            for (int i = 0; i < userList.Count; i++)
            {
                Add(new UserListInfo(userList[i].IsSelected,
                    userList[i].FirstName,
                    userList[i].LastName,
                    userList[i].UserId));
            }
        }
    }
}