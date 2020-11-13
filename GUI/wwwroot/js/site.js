// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.



getAllUser();
function getAllUser() {
	$(".userDisplay").empty();
	$.ajax({ //create an ajax request to load_page.php
		method: "GET",
		url: "/api/user/all",
		type: "JSON", //expect html to be returned
		success: function (data) {
			console.log(data);
			$.each(data, function (i, item) {
				var record = "<tr ><td>" + item.id + "</td>"
					+ "<td>" + item.username + "</td>"
					+ "<td>" + item.password + "</td>"
					+ "<td>" + item.email + "</td>"
					+ "<td>" + item.authLevelId + "</td>"
					+ "<td>" + "<button onclick='updateUser(" + item.id + ")'>Sửa</button>" + "</td>"
					+ "<td>" + "<button onclick='deleteUser(" + item.id + ")'>Xóa</button>" + "</td></tr>";
				$(".userDisplay").append(record);
			});
		}
	});
}
	


$(document).ready(function () {
	$("#createUser").submit(function (event) {
		event.preventDefault();
		var user = {
			Username: $("#username").val(),
			Password: $("#password").val(),
			Email: $("#email").val(),
			AuthLevelId: parseInt($("#authLevel").val())
		};
		console.log(user);
		$.ajax({
			method: "POST",
			url: "api/user/create",
			contentType: "application/json",
			dataType: "JSON",
			data: JSON.stringify(user),
			success: function (data) {
				alert("Thêm thành công");
			}
		});
	});
});



function deleteUser(id) {
	$.ajax({
		method: "DELETE",
		url: "api/user/all/" + id,
		success: function () {
			getAllUser();
		}
	})
}