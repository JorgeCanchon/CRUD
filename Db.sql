CREATE DATABASE Maestro
GO
USE Maestro
GO
CREATE TABLE Persona (
	IdPersona BIGINT PRIMARY KEY IDENTITY(1,1),
	Nombres VARCHAR(150) NOT NULL,
	Apellidos VARCHAR(150) NOT NULL,
	FechaNacimiento DATETIME NOT NULL,
	TipoIdentificacion VARCHAR(50) NOT NULL,
	NumeroIdentificacion BIGINT NOT NULL,
)
GO

CREATE PROCEDURE InsertarPersona
	@Nombres VARCHAR(150),
	@Apellidos VARCHAR(150),
	@FechaNacimiento DATETIME,
	@TipoIdentificacion VARCHAR(50),
	@NumeroIdentificacion BIGINT
AS
BEGIN
	INSERT INTO Persona(Nombres, Apellidos, FechaNacimiento, TipoIdentificacion, NumeroIdentificacion) 
	VALUES(@Nombres, @Apellidos, @FechaNacimiento, @TipoIdentificacion, @NumeroIdentificacion)

	SELECT @@IDENTITY
END
GO
CREATE PROC EliminarPersona
	@IdPersona BIGINT
AS
BEGIN
	IF (
		SELECT 
			COUNT(IdPersona) 
		FROM Persona WITH(NOLOCK)
		WHERE IdPersona = @IdPersona
	) > 0
	BEGIN
		DELETE FROM Persona
		WHERE IdPersona = @IdPersona 
	END
END
GO
CREATE PROC ActualizarPersona
	@IdPersona BIGINT,
	@Nombres VARCHAR(150),
	@Apellidos VARCHAR(150),
	@FechaNacimiento DATETIME,
	@TipoIdentificacion VARCHAR(50),
	@NumeroIdentificacion BIGINT
AS
BEGIN
	UPDATE Persona
	SET Nombres = @Nombres,
		Apellidos = @Apellidos,
		FechaNacimiento = @FechaNacimiento,
		TipoIdentificacion = @TipoIdentificacion,
		NumeroIdentificacion = @NumeroIdentificacion
	WHERE IdPersona = @IdPersona
END
GO
CREATE PROC ObtenerTodos

AS
BEGIN
	SELECT 
		IdPersona,
		Nombres,
		Apellidos,
		FechaNacimiento,
		TipoIdentificacion,
		NumeroIdentificacion
	FROM Persona WITH(NOLOCK)
END
GO
CREATE PROC ObtenerPersonaPorId
	@IdPersona BIGINT
AS
BEGIN
	SELECT 
		IdPersona,
		Nombres,
		Apellidos,
		FechaNacimiento,
		TipoIdentificacion,
		NumeroIdentificacion
	FROM Persona WITH(NOLOCK)
	WHERE IdPersona = @IdPersona
END
GO

