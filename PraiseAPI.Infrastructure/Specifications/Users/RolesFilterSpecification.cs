using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Specifications.Users
{
    public class RolesFilterSpecification : Specification<Role>
    {
        private readonly RolesQueryFilter _filter;

        public RolesFilterSpecification(RolesQueryFilter filter)
        {
            _filter = filter;

            var nameSpec = getRoleNameSpec();
            var descSpec = getRoleDescSpec();
            var displaySpec = getDisplayNameSpec();

            if (nameSpec != null)
                _expression = _expression == null ? nameSpec.Criteria() : (new Specification<Role>(_expression) | nameSpec).Criteria();
            if (descSpec != null)
                _expression = _expression == null ? descSpec.Criteria() : (new Specification<Role>(_expression) | descSpec).Criteria();
            if (displaySpec != null)
                _expression = _expression == null ? displaySpec.Criteria() : (new Specification<Role>(_expression) | displaySpec).Criteria();
        }


        private Specification<Role>? getRoleNameSpec()
            => string.IsNullOrEmpty(_filter.RoleName) ? null : new Specification<Role>(x => x.Name.Contains(_filter.RoleName));
        private Specification<Role>? getRoleDescSpec()
            => string.IsNullOrEmpty(_filter.Description) ? null : new Specification<Role>(x => x.Description.Contains(_filter.Description));
        private Specification<Role>? getDisplayNameSpec()
            => string.IsNullOrEmpty(_filter.DisplayName) ? null : new Specification<Role>(x => x.DisplayName.Contains(_filter.DisplayName));

    }
}
