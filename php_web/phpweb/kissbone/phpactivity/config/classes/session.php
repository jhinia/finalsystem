<?php
class Session {
    private $user_object_id;

    public function db_connect() {
        session_start();
        $this->check_stored_login();
    }

    public function login($user_object) {
        if ($user_object) {
            session_regenerate_id();
            $_SESSION['id'] = $user_object['account_id'];
            $this->user_object_id = $user_object['account_id'];
        }
        return true;
    }

    public function is_logged_in() {
        return isset($this->user_object_id);
    }

    public function logout() {
        unset($_SESSION['id']);
        unset($this->user_object_id);
        return true;
    }

    private function check_stored_login() {
        if (isset($_SESSION['id'])) {
            $this->user_object_id = $_SESSION['id'];
        }
    }
}
?>
