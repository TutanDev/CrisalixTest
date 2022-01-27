# Stress Balls 

Explicación breve sobre las decisiones tomadas sobre la realización de la prueba.


## Data en formato Asset

Los datos clave de la applicación como los tipos de bola o los posibles colores, se guardan usando ScriptableObjects en la carpeta Assets. Esto nos permito que ciertos componentes puedan cambiar sus valores y otros leerlos sin tener que acomplar los componentes.
### Ejemplo
El component **MaterialController.cs** actualiza las propiedades del material de la bola y no sabe quien esta seteando esas propiedades. Las setea el GameManager mediante los property setters en respuesta a los cambios en la UI.

## AppConfiguration y GameManager

La Appconfiguration es un asset que contiene todos los datos de la empresa con los tipos de bolas, restricciones y presets. El GameManager funciona como instalador de la app pasando al resto de componentes acceso a la parte de la configuracion que necesitan. Además, el GameManager es el único encargado de cambiar los valores en la configuración a través de los eventos que invoca el **ControlMenu**.

## Añadir nuevos tipos y presets

Para añadir nuevos tipos o presets, solo hay que crearlos en la carpeta assets haciendo 
*right click/Create/SO References* y añadirlos a la AppConfiguration. los menus de selección se inicializan con una lista de items y son dinamicos.

## BONUS: shaders

No se han implementado shaders. Posibles shaders a implementar:
1. Botones de seleccíon: tanto los botones para seleccionar el tipo de bola como los botones para seleccionar el color heredan de **BaseOpptionButton**. Usan dos sprites, una activo siempre y otro que se activa solo al estar seleccionados. Podemos implementarlo con un solo Image component y en el material aplicar el segundo sprite con un lerp con el factor campleado a 0 o a 1. También a los botones de colores se les puede implementar una animación de brillo cuando están seleccionados usando el mismo shader.
2. El fondo del menu de control en vez de ser negro con la opacidad baja podria ser un blur intenso. El blur es facil de implementar, se necesita una RenderTexture donde se renderice todo menos la UI. Aplicar esta textura con Screen coordinates al background y aplicar el blur. El blur puede hacer rápido bajando la resolucion de la imagen y subiendola, o implementar Gauss Blur Sampleando la textura varias veces y aplicando media de pixeles horizontalmente y verticalmente.
3. Por último ya que la aplicación esta relacionada con el estres y la relajación El menu principal podria ser un shader a pantalla completa relajante, mantienes pulsado y se hace un efecto de ola, cuando la ola llega a los bordes empieza la app.
