using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthTrack.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'Consultas', N'U') IS NULL
                BEGIN
                    CREATE TABLE [Consultas] (
                        [Id] INT NOT NULL IDENTITY,
                        [MedicoId] INT NOT NULL,
                        [PacienteId] INT NOT NULL,
                        [DataConsulta] DATETIME2 NOT NULL,
                        [Observacoes] NVARCHAR(MAX) NOT NULL,
                        CONSTRAINT [PK_Consultas] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_Consultas_Medicos_MedicoId] FOREIGN KEY ([MedicoId]) REFERENCES [Medicos] ([Id]) ON DELETE NO ACTION,
                        CONSTRAINT [FK_Consultas_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]) ON DELETE NO ACTION
                    );
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Consultas_MedicoId' AND object_id = OBJECT_ID(N'Consultas', N'U'))
                BEGIN
                    CREATE INDEX [IX_Consultas_MedicoId] ON [Consultas] ([MedicoId]);
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_Consultas_PacienteId' AND object_id = OBJECT_ID(N'Consultas', N'U'))
                BEGIN
                    CREATE INDEX [IX_Consultas_PacienteId] ON [Consultas] ([PacienteId]);
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF OBJECT_ID(N'Consultas', N'U') IS NOT NULL
                BEGIN
                    DROP TABLE [Consultas];
                END
            ");
        }
    }
}

