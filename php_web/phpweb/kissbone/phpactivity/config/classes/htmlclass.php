<?php 
Class HTML {
    static public function head(){
        include('components/head.php');
    }

    static public function sidebar($current_tab="dashboard"){
        include('components/sidebar.php');
    }

    static public function navbar(){
        include('components/navbar.php');
    }
    
    static public function footer(){
        include('components/footer.php');
    }
}
?>