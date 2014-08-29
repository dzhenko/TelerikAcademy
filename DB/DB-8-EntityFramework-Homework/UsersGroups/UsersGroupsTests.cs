namespace UsersGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersGroupsTests
    {
        public static void Main()
        {
            using (var db = new UsersGroupsEntities())
            {
                //db.Database.ExecuteSqlCommand(DBCreator.GetCreationString());

                using (var transaction = db.Database.BeginTransaction())
                {
                    var user = new User()
                    {
                        Username = "Pesho admina",
                    };

                    user.Groups.Add(CreateOrUseGroup(db, "Admins"));

                    db.Users.Add(user);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        transaction.Rollback();
                    }

                    transaction.Commit();
                }
            }
        }

        public static Group CreateOrUseGroup(UsersGroupsEntities db, string groupName)
        {
            var group = db.Groups.FirstOrDefault(g => g.Name == groupName);

            if (group == null)
            {
                group = new Group()
                {
                    Name = groupName
                };

                db.Groups.Add(group);
            }

            return group;
        }
    }
}
