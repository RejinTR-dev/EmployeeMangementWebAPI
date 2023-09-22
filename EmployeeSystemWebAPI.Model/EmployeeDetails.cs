using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystemWebAPI.Model
{/// <summary>
 /// Menu Class.
 /// </summary>
    public class EmployeeDetails
    {
        /// <summary>
        /// Gets or sets FirstName Model.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Emai_ID.
        /// </summary>
        public string Emai_ID { get; set; }

        /// <summary>
        /// Gets or sets PassWord.
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Gets or sets Confirm_PassWord.
        /// </summary>
        public string Confirm_PassWord { get; set; }
    }
}
