<?php
require_once('config/classes/session.php');

// Start the session
session_start();

// Instantiate the Session class
$session = new Session();

// Call the logout function from the Session class
$logoutSuccess = $session->logout();

// Redirect the user after logout
if ($logoutSuccess) {
    header('Location: index.php'); // Redirect to login page or any other page
    exit;
} else {
    // Handle logout failure
    echo "Logout failed!";
}
?>
