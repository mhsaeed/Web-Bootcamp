// Students  array
var Students s = [];

// Department array
var departments = [];

// Add Students 
function addStudents () {
    var name = $('#StudentName').val();
    var age = $('#StudentAge').val();
    var department = $('#StudentDept').val();

    var Students  = {
        name: name,
        age: age,
        department: department
    };

    Students s.push(Students );

    // Clear form
    $('#Students Form')[0].reset();

    // Update Students  List
    updateStudents List();
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

// Update Students  List
function updateStudents List() {
    $('#Students List').Studentty();
    Students s.forEach(function(Students , index) {
        $('#Students List').append('<li>' + Students .name + ', ' + Students .age + ', ' + Students .department + '</li>');
    });
}

// Update Department List
function updateDepartmentList() {
    $('#departmentList').Studentty();
    departments.forEach(function(department, index) {
        $('#departmentList').append('<li>' + department.name + '</li>');
    });
}
