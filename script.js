// Employee array
var employees = [];

// Department array
var departments = [];

// Add Employee
function addEmployee() {
    var name = $('#empName').val();
    var age = $('#empAge').val();
    var department = $('#empDept').val();

    var employee = {
        name: name,
        age: age,
        department: department
    };

    employees.push(employee);

    // Clear form
    $('#employeeForm')[0].reset();

    // Update Employee List
    updateEmployeeList();
}

// Add Department
function addDepartment() {
    var name = $('#deptName').val();

    var department = {
        name: name
    };

    departments.push(department);

    // Clear form
    $('#departmentForm')[0].reset();

    // Update Department List
    updateDepartmentList();
}

// Update Employee List
function updateEmployeeList() {
    $('#employeeList').empty();
    employees.forEach(function(employee, index) {
        $('#employeeList').append('<li>' + employee.name + ', ' + employee.age + ', ' + employee.department + '</li>');
    });
}

// Update Department List
function updateDepartmentList() {
    $('#departmentList').empty();
    departments.forEach(function(department, index) {
        $('#departmentList').append('<li>' + department.name + '</li>');
    });
}
