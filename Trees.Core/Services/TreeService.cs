using Trees.Core.Models;
using Trees.Core.Interfaces;
using System.Xml.Linq;

namespace Trees.Core.Services
{
    public class TreeService : ITreeService
    {
        public const int InfoItemValueCount = 4;
        public const string InfoValueSeparator = " ";

        public TreeService(
            ITreeRepository treeRepository,
            IImgService imgService,
            ILegService legService,
            IAssemblyMethodService assemblyMethodService,
            IMaterialService materialService,
            IBrandService brandService)
        {
            _treeRepository = treeRepository;
            _imgService = imgService;
            _legService = legService;
            _assemblyMethodService = assemblyMethodService;
            _materialService = materialService;
            _brandService = brandService;
        }

        public async Task CreateAsync(TreeDetails treeDetails)
        {
            Tree tree = await _ValidateTree(treeDetails);

            await _treeRepository.CreateAsync(tree);
        }

        public async Task UpdateAsync(TreeDetails treeDetails)
        {
            Tree tree = await _ValidateTree(treeDetails);

            await _treeRepository.UpdateAsync(tree);
        }

        public async Task<List<Tree>> GetAllAsync() => await _treeRepository.GetAllAsync();

        public async Task DeleteAsync(Guid id) => await _treeRepository.DeleteAsync(id);

        private async Task<Tree> _ValidateTree(TreeDetails treeDetails)
        {
            _ValidateInfo(treeDetails);

            List<Img> imgs = await _imgService.GetAsync(treeDetails.Imgs);

            if (imgs.Count == 0)
                throw new ArgumentException(nameof(imgs)); // todo 

            Tree tree = new() {
                Name = treeDetails.Name,
                InfoXml = _ConvertInfoToXml(treeDetails.Info),
                Imgs = imgs,
            };
   
            if (treeDetails.LegId.HasValue && (await _legService.GetAsync(treeDetails.LegId.Value) == null))
                tree.Leg = (await _legService.GetAsync(treeDetails.LegId.Value)) ?? throw new ArgumentException(nameof(treeDetails.LegId)); // todo

            if (treeDetails.AssemblyMethodId.HasValue)
                tree.AssemblyMethod = (await _assemblyMethodService.GetAsync(treeDetails.AssemblyMethodId.Value)) ?? throw new ArgumentException(nameof(treeDetails.AssemblyMethodId)); // todo 

            if (treeDetails.MaterialId.HasValue)
                tree.Material = (await _materialService.GetAsync(treeDetails.MaterialId.Value)) ?? throw new ArgumentException(nameof(treeDetails.MaterialId)); // todo 

            if (treeDetails.BrandId.HasValue)
                tree.Brand = (await _brandService.GetAsync(treeDetails.BrandId.Value)) ?? throw new ArgumentException(nameof(Brand)); // todo

            return tree;
        }

        private void _ValidateInfo(TreeDetails treeDetails)
        {
            if (treeDetails.Info == null || treeDetails.Info.Length == 0)
                throw new ArgumentException(nameof(treeDetails.Info)); // todo

            foreach (var value in treeDetails.Info)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(value)); // todo

                string[] items = value.Split(InfoValueSeparator);

                if (items.Length != InfoItemValueCount)
                    throw new ArgumentException(nameof(value)); // todo
            }
        }

        private string _ConvertInfoToXml(string[] info)
        {
            XElement itemsXmlElement = new(ITEMS_XML_ELEMENT);

            foreach (var value in info)
            {
                string[] items = value.Split(InfoValueSeparator);

                XElement itemXmlElement = new XElement(ITEM_XML_ELEMENT);

                itemXmlElement.Add(new XElement(HEIGHT_XML_ELEMENT, items[HEIGHT_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(DIAMETER_XML_ELEMENT, items[DIAMETER_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(TIPS_XML_ELEMENT, items[TIPS_XML_ELEMENT_INDEX]));
                itemXmlElement.Add(new XElement(PRICE_XML_ELEMENT, items[PRICE_XML_ELEMENT_INDEX]));

                itemsXmlElement.Add(itemXmlElement);
            }

            return XElement.Parse(itemsXmlElement.ToString()).ToString(SaveOptions.DisableFormatting);
        }

        private const string ITEMS_XML_ELEMENT = "items";
        private const string ITEM_XML_ELEMENT = "item";
        private const string HEIGHT_XML_ELEMENT = "height";
        private const string DIAMETER_XML_ELEMENT = "diameter";
        private const string TIPS_XML_ELEMENT = "tips";
        private const string PRICE_XML_ELEMENT = "price";

        private const int HEIGHT_XML_ELEMENT_INDEX = 0;
        private const int DIAMETER_XML_ELEMENT_INDEX = 1;
        private const int TIPS_XML_ELEMENT_INDEX = 2;
        private const int PRICE_XML_ELEMENT_INDEX = 3;

        private readonly ITreeRepository _treeRepository;
        private readonly IImgService _imgService;
        private readonly ILegService _legService;
        private readonly IAssemblyMethodService _assemblyMethodService;
        private readonly IMaterialService _materialService;
        private readonly IBrandService _brandService;
    }
}
