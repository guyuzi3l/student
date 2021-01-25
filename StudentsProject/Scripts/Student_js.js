// The function load all students from DB
function loadStudents() {
    debugger
    $.ajax({
        dataType: 'json',
        url: '/api/students',
        contentType: 'application/json',//how we want to send
        type: "GET", // OR method:"GET"
        success: (data) => {
            $("#divError").hide();
            $("#divSuccess").hide();
            if (data != null) {
                if ($("#students").html())
                    $("#students").empty();
                for (var i = 0; i < data.length; i++) {
                    var $p = $("<p>"); //יצירת תגית של פסקה
                    $p.html(`${data[i].Student_Name} , ${data[i].Student_Id}`);
                    $("#students").append($p);
                }
                $("#divSuccess").show();
            }
            else {
                $("#divError").show();
            }
        },
        error: (err) => {
            console.log(err)
        }
    })
}
//The function updates student name to existing student
function updateStudent() {
    //cancel the refresh of form 
    event.preventDefault()

    let id = $("#studentId").val()
    let name = $("#studentName").val()

    $.ajax({
        dataType: "json", //default
        url: `/api/students/${id}`,
        contentType: 'application/json',//how we want to send
        type: "PUT", // OR method:"GET"
        data: JSON.stringify(name),
        success: (data) => {
            debugger
            $("#divError").hide();
            $("#divSuccess").hide();
            loadStudents();
   
        },
        error: (err) => {
            $("#divError").show();

        }
    })
}
//The function insert a new student to DB
function postStudent() {
    var student = {
        Student_Id: $("#newStudentId").val(),
        Student_Name: $("#newStudentName").val(),
        Is_Active: true,
        Avg_Grade: $("#newStudentAvg").val()
    }

    $.ajax({
        dataType: "json", //default
        url: `/api/students`,
        contentType: 'application/json',//how we want to send
        type: "post", // OR method:"GET"
        data: JSON.stringify(student),
        success: (data) => {
            $("#divError").hide();
            $("#divSuccess").show();

        },
        error: (err) => {
            $("#divError").show();

        }
    })
}
