flowchart TB
Bitmap(Bitmap)
CommonObject(CommonObject)
Curve(Curve)
GH_ActiveObject(GH_ActiveObject)
GH_Component(GH_Component)
GH_DocumentObject(GH_DocumentObject)
GH_Exposure(GH_Exposure)
GH_ISerializable(GH_ISerializable)
GH_InputParamManager(GH_InputParamManager)
GH_InstanceDescription(GH_InstanceDescription)
GH_OutputParamManager(GH_OutputParamManager)
GH_ParamAccess(GH_ParamAccess)
GH_RuntimeMessageLevel(GH_RuntimeMessageLevel)
GH_TaskCapableComponent(GH_TaskCapableComponent)
Guid(Guid)
IGH_ActiveObject(IGH_ActiveObject)
IGH_BakeAwareObject(IGH_BakeAwareObject)
IGH_Component(IGH_Component)
IGH_DataAccess(IGH_DataAccess)
IGH_DocumentObject(IGH_DocumentObject)
IGH_InstanceDescription(IGH_InstanceDescription)
IGH_PreviewObject(IGH_PreviewObject)
IGH_RenderAwareObject(IGH_RenderAwareObject)
IGH_TaskCapableComponent(IGH_TaskCapableComponent)
Interval(Interval)
Math(Math)
Object(Object)
Resources(Resources)
RhinoMath(RhinoMath)
SolveResults(SolveResults)
TaskCapableComponent(TaskCapableComponent)

Bitmap  -->  Bitmap 
Bitmap  -..-|>  Object 
CommonObject  -->  CommonObject 
CommonObject  -->  Object 
CommonObject  -..->  Object 
Curve  -..-|>  CommonObject 
Curve  -->  Curve 
Curve  -->  Interval 
Curve  -..-|>  Object 
GH_ActiveObject  -..-|>  GH_DocumentObject 
GH_ActiveObject  -..-|>  GH_ISerializable 
GH_ActiveObject  -..-|>  GH_InstanceDescription 
GH_ActiveObject  -->  GH_RuntimeMessageLevel 
GH_ActiveObject  -..-|>  IGH_ActiveObject 
GH_ActiveObject  -->  IGH_ActiveObject 
GH_ActiveObject  -..-|>  IGH_DocumentObject 
GH_ActiveObject  -..-|>  IGH_InstanceDescription 
GH_ActiveObject  -..-|>  Object 
GH_ActiveObject  -..->  Object 
GH_Component  -..-|>  GH_ActiveObject 
GH_Component  -..-|>  GH_DocumentObject 
GH_Component  -..-|>  GH_ISerializable 
GH_Component  -..-|>  GH_InstanceDescription 
GH_Component  -->  GH_RuntimeMessageLevel 
GH_Component  -..-|>  IGH_ActiveObject 
GH_Component  -..-|>  IGH_BakeAwareObject 
GH_Component  -..-|>  IGH_Component 
GH_Component  -..-|>  IGH_DocumentObject 
GH_Component  -..-|>  IGH_InstanceDescription 
GH_Component  -..-|>  IGH_PreviewObject 
GH_Component  -..-|>  IGH_RenderAwareObject 
GH_Component  -..-|>  Object 
GH_DocumentObject  -..->  Bitmap 
GH_DocumentObject  -->  Bitmap 
GH_DocumentObject  -->  GH_Exposure 
GH_DocumentObject  -..-|>  GH_ISerializable 
GH_DocumentObject  -..-|>  GH_InstanceDescription 
GH_DocumentObject  -->  Guid 
GH_DocumentObject  -..-|>  IGH_DocumentObject 
GH_DocumentObject  -..-|>  IGH_InstanceDescription 
GH_DocumentObject  -..-|>  Object 
GH_Exposure  -..-|>  Object 
GH_InputParamManager  -..-|>  Object 
GH_InstanceDescription  -..-|>  GH_ISerializable 
GH_InstanceDescription  -->  Guid 
GH_InstanceDescription  -..->  Guid 
GH_InstanceDescription  -..-|>  IGH_InstanceDescription 
GH_OutputParamManager  -..-|>  Object 
GH_ParamAccess  -..-|>  Object 
GH_RuntimeMessageLevel  -..-|>  Object 
GH_TaskCapableComponent  -..-|>  GH_ActiveObject 
GH_TaskCapableComponent  -..-|>  GH_Component 
GH_TaskCapableComponent  -..-|>  GH_DocumentObject 
GH_TaskCapableComponent  -..-|>  GH_ISerializable 
GH_TaskCapableComponent  -..-|>  GH_InstanceDescription 
GH_TaskCapableComponent  -..-|>  IGH_ActiveObject 
GH_TaskCapableComponent  -..-|>  IGH_BakeAwareObject 
GH_TaskCapableComponent  -..-|>  IGH_Component 
GH_TaskCapableComponent  -..-|>  IGH_DocumentObject 
GH_TaskCapableComponent  -..-|>  IGH_InstanceDescription 
GH_TaskCapableComponent  -..-|>  IGH_PreviewObject 
GH_TaskCapableComponent  -..-|>  IGH_RenderAwareObject 
GH_TaskCapableComponent  -..-|>  IGH_TaskCapableComponent 
GH_TaskCapableComponent  -..-|>  Object 
Guid  -..->  Guid 
Guid  -->  Guid 
Guid  -..-|>  Object 
IGH_ActiveObject  -..-|>  GH_ISerializable 
IGH_ActiveObject  -->  GH_RuntimeMessageLevel 
IGH_ActiveObject  -..-|>  IGH_DocumentObject 
IGH_ActiveObject  -..-|>  IGH_InstanceDescription 
IGH_Component  -..-|>  GH_ISerializable 
IGH_Component  -..-|>  IGH_ActiveObject 
IGH_Component  -..-|>  IGH_BakeAwareObject 
IGH_Component  -..-|>  IGH_DocumentObject 
IGH_Component  -..-|>  IGH_InstanceDescription 
IGH_Component  -..-|>  IGH_PreviewObject 
IGH_DocumentObject  -->  Bitmap 
IGH_DocumentObject  -->  GH_Exposure 
IGH_DocumentObject  -..-|>  GH_ISerializable 
IGH_DocumentObject  -->  Guid 
IGH_DocumentObject  -..-|>  IGH_InstanceDescription 
IGH_InstanceDescription  -..-|>  GH_ISerializable 
IGH_InstanceDescription  -->  Guid 
IGH_TaskCapableComponent  -..-|>  GH_ISerializable 
IGH_TaskCapableComponent  -..-|>  IGH_ActiveObject 
IGH_TaskCapableComponent  -..-|>  IGH_BakeAwareObject 
IGH_TaskCapableComponent  -..-|>  IGH_Component 
IGH_TaskCapableComponent  -..-|>  IGH_DocumentObject 
IGH_TaskCapableComponent  -..-|>  IGH_InstanceDescription 
IGH_TaskCapableComponent  -..-|>  IGH_PreviewObject 
Interval  -->  Interval 
Interval  -->  Interval 
Interval  -..-|>  Object 
Object  -->  Object 
Resources  -->  Bitmap 
Resources  -->  Bitmap 
SolveResults  -->  Curve 
TaskCapableComponent  -->  Bitmap 
TaskCapableComponent  -->  Bitmap 
TaskCapableComponent  -->  CommonObject 
TaskCapableComponent  -->  Curve 
TaskCapableComponent  -->  GH_ActiveObject 
TaskCapableComponent  -..-|>  GH_ActiveObject 
TaskCapableComponent  -..-|>  GH_Component 
TaskCapableComponent  -..-|>  GH_DocumentObject 
TaskCapableComponent  -->  GH_Exposure 
TaskCapableComponent  -->  GH_Exposure 
TaskCapableComponent  -..-|>  GH_ISerializable 
TaskCapableComponent  -->  GH_InputParamManager 
TaskCapableComponent  -..-|>  GH_InstanceDescription 
TaskCapableComponent  -->  GH_OutputParamManager 
TaskCapableComponent  -->  GH_ParamAccess 
TaskCapableComponent  -->  GH_RuntimeMessageLevel 
TaskCapableComponent  -..-|>  GH_TaskCapableComponent 
TaskCapableComponent  -->  GH_TaskCapableComponent 
TaskCapableComponent  -->  Guid 
TaskCapableComponent  -..-|>  IGH_ActiveObject 
TaskCapableComponent  -..-|>  IGH_BakeAwareObject 
TaskCapableComponent  -..-|>  IGH_Component 
TaskCapableComponent  -->  IGH_DataAccess 
TaskCapableComponent  -..-|>  IGH_DocumentObject 
TaskCapableComponent  -..-|>  IGH_InstanceDescription 
TaskCapableComponent  -..-|>  IGH_PreviewObject 
TaskCapableComponent  -..-|>  IGH_RenderAwareObject 
TaskCapableComponent  -..-|>  IGH_TaskCapableComponent 
TaskCapableComponent  -->  Interval 
TaskCapableComponent  -->  Math 
TaskCapableComponent  -..-|>  Object 
TaskCapableComponent  -->  Resources 
TaskCapableComponent  -->  RhinoMath 
TaskCapableComponent  -->  SolveResults 
TaskCapableComponent  -->  SolveResults 
