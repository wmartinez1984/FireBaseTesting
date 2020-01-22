<?php

echo $_GET['nombre'];









function tommus_email_validate($email) { return filter_var($email, FILTER_VALIDATE_EMAIL) && preg_match('/@.+\./', $email); }




$address = 'fernandoestradasans@gmail.com';

?>