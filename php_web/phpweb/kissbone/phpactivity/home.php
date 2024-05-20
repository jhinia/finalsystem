<?php
   include("config/initialize.php");

   HTML :: head();
   $current_tab = "";

   if(isset($_GET['tab']))
   {
    $current_tab = $_GET['tab'];
   }

   HTML :: sidebar($current_tab);
   HTML :: navbar();

   if($current_tab == "dashboard"){
      dashboard();
   }

   if($current_tab == "allroom"){
      allroom();
   }

   if($current_tab == "allguest"){
      allguest();
   }

   if($current_tab == "addguest"){
      addguest();
   }

   if($current_tab == "addroom"){
      addroom();
   }

   HTML ::footer();

?>
