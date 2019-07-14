using PlayBall.GroupManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayBall.GroupManagement.Business.Models;
using System.Collections.ObjectModel;

namespace PlayBall.GroupManagement.Web.Mappings
{
    public static class GroupMapping
    {

        public static GroupViewModel ToViewModel(this Group model)
        {
            return model != null ? new GroupViewModel { Id = model.Id, Name = model.Name }: null;
        }

        public static Group ToServiceModel(this GroupViewModel model)
        {
            return model != null ? new Group { Id = model.Id, Name = model.Name } : null;
        }

        // Extension method is used to extend class is referencing to (using the "this" keyword,
        //  in this case IReadOnlyCollection<Group>. By doing this we can  call the method
        // as if it was defined in the type. Method must be static.
        public static IReadOnlyCollection<GroupViewModel> ToViewModel(this IReadOnlyCollection<Group> models)
        {
            if(models.Count == 0)
            {
                return Array.Empty<GroupViewModel>();
            }

            var groups = new GroupViewModel[models.Count];
            var i = 0;
            foreach (var model in models)
            {
                groups[i] = model.ToViewModel();
                i++;
            }

            return new ReadOnlyCollection<GroupViewModel>(groups);
            
        }


    }
}
