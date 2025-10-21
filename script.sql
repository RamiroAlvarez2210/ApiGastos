-- Comando que registra que la migración inicial ya se aplicó:
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'2025101402129_InitialCreate', N'VERSION_DE_EF_CORE');
GO