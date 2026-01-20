public enum SystemState
{
    Idle,           // Sistem açık ama çalışmıyor
    Running,        // Normal çalışma
    Paused,         // Manuel durdurma
    Fault,          // Hata var ama acil değil
    EmergencyStop   // HER ŞEY DURUR
}
